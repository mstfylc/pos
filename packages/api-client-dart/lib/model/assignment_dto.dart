//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/assignment_record_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_dto.g.dart';

abstract class AssignmentDto implements Built<AssignmentDto, AssignmentDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'assignmentTableType')
    int get assignmentTableType;

    @BuiltValueField(wireName: r'records')
    BuiltList<AssignmentRecordDto> get records;

    AssignmentDto._();

    static void _initializeBuilder(AssignmentDtoBuilder b) => b;

    factory AssignmentDto([void updates(AssignmentDtoBuilder b)]) = _$AssignmentDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<AssignmentDto> get serializer => _$AssignmentDtoSerializer();
}

class _$AssignmentDtoSerializer implements StructuredSerializer<AssignmentDto> {

    @override
    final Iterable<Type> types = const [AssignmentDto, _$AssignmentDto];
    @override
    final String wireName = r'AssignmentDto';

    @override
    Iterable<Object> serialize(Serializers serializers, AssignmentDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'assignmentTableType')
            ..add(serializers.serialize(object.assignmentTableType,
                specifiedType: const FullType(int)));
        result
            ..add(r'records')
            ..add(serializers.serialize(object.records,
                specifiedType: const FullType(BuiltList, [FullType(AssignmentRecordDto)])));
        return result;
    }

    @override
    AssignmentDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'assignmentTableType':
                    result.assignmentTableType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'records':
                    result.records.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(AssignmentRecordDto)])) as BuiltList<AssignmentRecordDto>);
                    break;
            }
        }
        return result.build();
    }
}

