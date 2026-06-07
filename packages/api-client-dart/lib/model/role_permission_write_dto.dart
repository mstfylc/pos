//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'role_permission_write_dto.g.dart';

abstract class RolePermissionWriteDto implements Built<RolePermissionWriteDto, RolePermissionWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'permissionIds')
    BuiltList<String> get permissionIds;

    RolePermissionWriteDto._();

    static void _initializeBuilder(RolePermissionWriteDtoBuilder b) => b;

    factory RolePermissionWriteDto([void updates(RolePermissionWriteDtoBuilder b)]) = _$RolePermissionWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<RolePermissionWriteDto> get serializer => _$RolePermissionWriteDtoSerializer();
}

class _$RolePermissionWriteDtoSerializer implements StructuredSerializer<RolePermissionWriteDto> {

    @override
    final Iterable<Type> types = const [RolePermissionWriteDto, _$RolePermissionWriteDto];
    @override
    final String wireName = r'RolePermissionWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, RolePermissionWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'permissionIds')
            ..add(serializers.serialize(object.permissionIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    RolePermissionWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RolePermissionWriteDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'permissionIds':
                    result.permissionIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

